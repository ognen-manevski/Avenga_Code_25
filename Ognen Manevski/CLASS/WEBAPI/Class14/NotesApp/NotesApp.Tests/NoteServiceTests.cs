using Moq;
using NotesApp.DataAccess.Implementations.EntityFramework;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Enums;
using NotesApp.Domain.Models;
using NotesApp.Dtos;
using NotesApp.Services.CustomExceptions;
using NotesApp.Services.Implementations;


namespace NotesApp.Tests;

// ===> Naming Convention
// MethodName_StateUnderTest_ExpectedBehavior

// ===> AAA => Arange - Act - Assert
// *Arrange* => Set up the test by preparing the objects, mocking dependencies, and setting the initial state.
// *Act* => Execute the action or method that is being tested.
// *Assert* =>  Verify that the outcome from the action is as expected, confirming that the method works correctly.

// ===> Mocking is a technique used in unit testing to create fake objects

[TestClass] 
public class NoteServiceTests
{
    private Mock<INoteRepository> _noteRepositoryMock;
    private Mock<IUserRepository> _userRepositoryMock;
    private Mock<ITagRepository> _tagRepositoryMock;

    private NoteService _noteService;

    private const int UserId = 100;

    [TestInitialize]
    public void Setup()
    {
        _noteRepositoryMock = new Mock<INoteRepository>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _tagRepositoryMock = new Mock<ITagRepository>();

        _noteService = new NoteService(
            _noteRepositoryMock.Object,
            _userRepositoryMock.Object,
            _tagRepositoryMock.Object
        );
    }

    [TestMethod]
    public async Task GetAllNotesAsync_WhenNoPriorityIsGiven_ReturnsEntitiesAndMapsThem()
    {
        // Arrange
        string noteText = "Testing with MSTest";
        Note note = CreateNote(5, UserId, noteText, Priority.High);
        List<Note> notesDb = [note];

        _noteRepositoryMock.Setup(repo => repo.GetAllAsync(UserId)).ReturnsAsync(notesDb);

        // Act
        List<NoteDto> result = await _noteService.GetAllNotesAsync(UserId);

        // Assert 
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(noteText, result[0].Text);
        Assert.AreEqual(note.User.FullName, result[0].UserFullName);
    }

    [TestMethod]
    public async Task GetNoteByIdAsync_WhenNoteIsNotFound_ThrowsNotNotFoundException()
    {
        // Arrange
        int noteId = 500;
        string errorMessage = $"Note with id {noteId} not found.";

        _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(noteId)).ReturnsAsync((Note?)null);

        // Act & Assert
        NoteNotFoundException result = await 
            Assert.ThrowsExactlyAsync<NoteNotFoundException>(() =>
            _noteService.GetNoteByIdAsync(noteId, UserId));   

        Assert.AreEqual(errorMessage, result.Message);
        _noteRepositoryMock.Verify(repo => repo.GetByIdAsync(noteId),
            Times.AtLeastOnce);
    }

    [TestMethod]
    public async Task GetNoteByID_WhenNoteExistsAndUserIsOwner_ReturnsNoteDto()
    {
        //Arrange
        int noteId = 500;
        string noteText = "Testing with MSTest";
        Note note = CreateNote(noteId, UserId, noteText, Priority.High);

        _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(noteId)).ReturnsAsync(note);
        //_noteRepositoryMock.Setup(repo => repo.EnsureOwner(note, UserId));

        // Act
        NoteDto result = await _noteService.GetNoteByIdAsync(noteId, UserId);

        // Assert
        Assert.AreEqual(noteId, result.Id);
        Assert.AreEqual(noteText, result.Text);
        Assert.AreEqual(note.User?.FullName, result.UserFullName);
        Assert.AreEqual(note.Priority, result.Priority);
        _noteRepositoryMock.Verify(repo => repo.GetByIdAsync(noteId), Times.Once);
    }



    #region Helper methods

    private static Note CreateNote(int id, int userId, string text, Priority priority = Priority.Low)
    {
        return new Note
        {
            Id = id,
            Text = text,
            Priority = priority,
            UserId = userId,
            User = CreateUser(userId),
            Tags = new List<Tag>()
        };
    }

    private static Domain.Models.User CreateUser(int id)
    {
        return new Domain.Models.User
        {
            Id = id,
            FirstName = "John",
            LastName = "Doe",
            Username = "johnny",
            Password = "hashed-password"
        };
    }

    #endregion

}
