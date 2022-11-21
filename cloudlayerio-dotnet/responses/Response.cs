using System;

namespace cloudlayerio_dotnet.responses;

public class Response<T>
{
    public int ApiCreditCost { get; set; }

    public string AssetId { get; set; }

    public string AssetUrl { get; set; }

    public string FileId { get; set; }

    public string Id { get; set; }

    public string Self { get; set; }

    public StatusEnum Status { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public string UserId { get; set;  }

    public string WorkerName { get; set; }
    
    public T Params { get; set; }
}