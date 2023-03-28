namespace ApiTrottling.Application.Common.CommandsAndQueries.GetDate.Queries.GetDate;
public class GetDateVm
{
    public DateTime Now { get; set; }

    public GetDateVm()
    {
        Now = DateTime.UtcNow;
    }
}
