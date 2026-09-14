using Moq;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Dtos;
using NotesApp.Services.Implementations;


namespace NotesApp.Tests;

[TestClass]
public class NoteServiceTests
{
    private Mock<INoteRepository> _noteRepositoryMock;
    private Mock<IUserRepository> _userRepositoryMock;
    private Mock<ITagRepository> _tagRepositoryMock;

    private NoteService _noteService;

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

    //MethodName_StateUnderTest(the scenatio)_ExpectedBehavior
    [TestMethod]
    public async Task GetAllNotesAsync_WhenNoPriorityISGiven_ReturnsEntitiesAnd MapsThem()
    {
        //AAA => Arrange -Act - Assert

    //Arrange
    int userId = 100;
    NoteDto note = new NoteDto
    {
        Id = 1,
        Text = "Testing with MSTest"
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        UserId = userId,
        Priority = Priority.High,
        Tags = []
    };
    }

    //ac
    List<NoteDto> tesult = _noteService.GetAllNotesAsync();




    //Assert


}




}
