Hrithik.Security.Correlation

A lightweight, secure, and enterprise-ready Correlation ID library for .NET applications.

Hrithik.Security.Correlation provides automatic correlation ID generation, validation, propagation, and logging enrichment for distributed systems—without the overhead of full tracing frameworks.

✨ Features

🔗 Automatic Correlation ID management

🌐 ASP.NET Core middleware

📤 Outgoing HTTP propagation (HttpClient)

🧵 Async-safe context (AsyncLocal)

📜 Logging enrichment (ILogger scopes)

🔐 Optional strict validation

⚙️ Fully configurable

🧩 Minimal dependencies

📦 Installation
dotnet add package Hrithik.Security.Correlation


Optional integrations:

dotnet add package Hrithik.Security.Correlation.AspNetCore
dotnet add package Hrithik.Security.Correlation.Http
dotnet add package Hrithik.Security.Correlation.Logging

🧠 Why Correlation IDs?

In distributed systems:

One user request → many services

Logs become impossible to trace

Debugging production issues is painful

A Correlation ID solves this by attaching a single identifier to a request across:

APIs

Downstream services

Logs

Exceptions

🚀 Quick Start
1️⃣ Register Services
builder.Services.AddCorrelation(options =>
{
    options.HeaderName = "X-Correlation-Id";
    options.GenerateIfMissing = true;
    options.StrictValidation = true;
});

2️⃣ Enable Middleware
app.UseCorrelation();


This will:

Read correlation ID from request headers

Generate one if missing

Validate format

Attach it to the response headers

3️⃣ Access Correlation ID Anywhere
public class OrderService
{
    private readonly ICorrelationContext _correlation;

    public OrderService(ICorrelationContext correlation)
    {
        _correlation = correlation;
    }

    public void Process()
    {
        Console.WriteLine(_correlation.CorrelationId);
    }
}

🌐 HTTP Client Propagation

Automatically propagate the same correlation ID to downstream services.

builder.Services.AddHttpClient("DownstreamApi")
    .AddHttpMessageHandler<CorrelationDelegatingHandler>();


Outgoing requests will include:

X-Correlation-Id: <same-id>

📜 Logging Integration

Enrich logs with correlation ID using logging scopes.

using (_logger.BeginCorrelationScope(_correlationContext))
{
    _logger.LogInformation("Processing request");
}


Example log output:

{
  "Message": "Processing request",
  "CorrelationId": "a9b12c1e5f9a4b5b9a9d0e1f8b3d2a1c"
}

⚙️ Configuration Options
Option	Default	Description
HeaderName	X-Correlation-Id	Header used for correlation
GenerateIfMissing	true	Generate ID if missing
StrictValidation	false	Enforce validation
MaxLength	64	Maximum allowed length
🔐 Security Considerations

Prevents header spoofing (optional)

Limits correlation ID length

Rejects invalid incoming requests

Designed for zero-trust environments

🧩 Package Structure
Hrithik.Security.Correlation
├── Abstractions
├── Core
├── AspNetCore
├── Http
└── Logging


Each module can be used independently.

🆚 Alternatives
Solution	Drawbacks
Custom middleware	Reinvented in every project
OpenTelemetry	Heavy & complex
DIY logging	No propagation

Hrithik.Security.Correlation focuses on one thing and does it well.

🛣 Roadmap

gRPC interceptor

Serilog enricher

Azure Functions support

W3C traceparent compatibility

OpenTelemetry bridge

🤝 Contributing

Contributions, issues, and feature requests are welcome.

📄 License

MIT License


## 👤 Author

**Hrithik Kalra**

.NET | API Security | Fintech Systems

📧 Email: hrithikkalra11@gmail.com

GitHub: https://github.com/hrithikalra

LinkedIn: https://www.linkedin.com/in/hrithik-kalra-b6836a246/

If you find this package useful, consider supporting its development:

- ☕ Buy Me a Coffee: https://www.buymeacoffee.com/alkylhalid9  
- ❤️ GitHub Sponsors: https://github.com/sponsors/hrithikalra

Support is entirely optional and helps sustain ongoing development and maintenance.

---

## 🔗 Related Packages

This package is part of the **Hrithik.Security** ecosystem:

- **Hrithik.Security.ApiKeyManagement**  
  API key generation, storage, and scope-based authorization

- **Hrithik.Security.RequestSigning**  
  HMAC-based request signing for tamper-proof APIs

- **Hrithik.Security.ReplayProtection**  
  Short-window replay attack prevention

- **Hrithik.Security.RateLimiting**  
  Flexible, API-key–aware rate limiting for ASP.NET Core APIs

- **Hrithik.Security.Idempotency**
  Idempotency-key–based protection for safe retries in financial APIs

- **Hrithik.Security.Jose**
  JWT and JWS utilities for secure token handling and message signing

- **Hrithik.Security.AuditLogging**
  Compliance-grade, tamper-evident audit logging for .NET APIs

- **Hrithik.Security.Headers**
  Strongly-typed and validated security HTTP headers for ASP.NET Core.

  Together, they form a complete API security framework.

These packages are **independent** and can be used together or individually.
