namespace BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs
{
    public record BookUpdateRequestDTO(int Id, string Title, string Author, string PublicationDate, decimal Price);
}
