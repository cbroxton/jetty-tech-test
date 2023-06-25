namespace api.Models.AppSettings;

public class JWTSettings {
    public string Issuer { get; set; } = "";
    public string Audience { get; set; } = "";
    public string Key { get; set; } = "";
}
