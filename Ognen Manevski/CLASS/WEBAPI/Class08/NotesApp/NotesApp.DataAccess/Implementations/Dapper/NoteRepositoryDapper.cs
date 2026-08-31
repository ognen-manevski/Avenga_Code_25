using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Implementations.Dapper;

public class NoteRepositoryDapper : INoteRepository
{
    private readonly string _connectionString;

    public NoteRepositoryDapper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("NotesAppDb")
            ?? throw new InvalidOperationException("Connection string 'NotesAppDb' not found.");
    }


    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public async Task<List<Note>> GetAllAsync()
    {
        using SqlConnection connection = CreateConnection();

        string query = "SELECT * FROM dbo.Note"; //example query

        IEnumerable<Note> notes = await connection.QueryAsync<Note>(query);

        return notes.ToList();
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Note>> GetByIdsAsync(List<int> ids)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Note entity)
    {
        using SqlConnection connection = CreateConnection();
        await connection.OpenAsync();

        //ensure that the insert operation is atomic
        using SqlTransaction transaction = connection.BeginTransaction();

        const string insertQuery = @"
            INSERT INTO dbo.Note (Text, Priority, UserId, CreatedDate, UpdatedDate)
            OUTPUT INSERTED.Id, INSERTED.CreatedDate, INSERTED.UpdatedDate
            VALUES (@Text, @Priority, @UserId, GETUTCDATE(), GETUTCDATE());
            ";

        Note Inserted = await connection.QuerySingleAsync<Note>(
            sql: insertQuery,
            param: new { entity.Text, Priority = entity.Priority.ToString(), entity.UserId },
            transaction: transaction
        );

        entity.Id = Inserted.Id;
        entity.CreatedDate = Inserted.CreatedDate;
        entity.UpdatedDate = Inserted.UpdatedDate;  

        await SaveTagsAsync(connection, transaction, entity);

        await transaction.CommitAsync();
    }


    private static async Task SaveTagsAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        Note entity
        )
    {
        await connection.ExecuteAsync(
            "DELETE FROM dbo.NoteTag WHERE NoteID = @NoteId",
            new { NoteId = entity.Id },
            transaction
        );

        await connection.ExecuteAsync(
            "INSERT INTO dbo.NoteTag (NoteID, TagID) VALUES (@NoteId, @TagId)",
            param: entity.Tags.Select(tag => new { NoteId = entity.Id, TagId = tag.Id }),
            transaction: transaction
        );
    }


    public async Task UpdateAsync(Note entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Note entity)
    {
        using SqlConnection connection = CreateConnection();
        await connection.ExecuteAsync("DELETE FROM dbo.Note WHERE Id = @Id", new { Id = entity.Id });
    }
}
