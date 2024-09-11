namespace nheejods.Dtos.Commons;

public class BaseResponseDto<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public DateTime ResponseTime { get; } = DateTime.Now;
    public T? Data { get; set; }
}
