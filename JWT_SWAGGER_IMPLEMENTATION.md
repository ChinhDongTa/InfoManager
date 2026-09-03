/*
 * ╔════════════════════════════════════════════════════════════════╗
 * ║          JWT AUTHENTICATION IN SWAGGER - SUMMARY              ║
 * ╚════════════════════════════════════════════════════════════════╝
 * 
 * CHANGES MADE:
 * ============
 * 
 * 1️⃣ Program.cs
 *    ✓ Keep it simple - just register services
 *    ✓ configure.AddSecurity("Bearer", ...) handles JWT in Swagger
 *    ✓ No need for Swashbuckle - we use NSwag
 * 
 * 2️⃣ DependencyInjection.cs (AddWebServices method)
 *    ✓ Uncommented configure.AddSecurity("Bearer", ...)
 *    ✓ Changed Type from ApiKey to Http (proper HTTP Bearer)
 *    ✓ Added Scheme = "Bearer" and BearerFormat = "JWT"
 *    ✓ Added AspNetCoreOperationSecurityScopeProcessor
 * 
 * ════════════════════════════════════════════════════════════════
 * 
 * HOW IT WORKS IN SWAGGER UI:
 * ==========================
 * 
 *   ┌─────────────────────────────────────────────────────────┐
 *   │  Swagger UI                                             │
 *   │  ┌───────────────────────────────────────────────────┐ │
 *   │  │  InfoManager API                  🔓 Authorize   │ │  ← Authorize button
 *   │  ├───────────────────────────────────────────────────┤ │
 *   │  │  POST /auth/login                               │ │
 *   │  │    - Login endpoint (returns JWT token)          │ │
 *   │  │                                                   │ │
 *   │  │  GET /api/profile 🔒                             │ │  ← Protected endpoint
 *   │  │    - Requires Bearer token in Authorization      │ │
 *   │  │                                                   │ │
 *   │  │  POST /api/users 🔒                              │ │  ← Protected endpoint
 *   │  └───────────────────────────────────────────────────┘ │
 *   └─────────────────────────────────────────────────────────┘
 * 
 * ════════════════════════════════════════════════════════════════
 * 
 * WORKFLOW:
 * ========
 * 
 *   Step 1: Get Token
 *   ─────────────────
 *   POST /auth/login
 *   {
 *     "email": "user@example.com",
 *     "password": "password123"
 *   }
 *   
 *   Response:
 *   {
 *     "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
 *     "refreshToken": "...",
 *     "expiresIn": 3600
 *   }
 * 
 *   Step 2: Authorize in Swagger
 *   ──────────────────────────
 *   Click "🔓 Authorize" button
 *   Enter: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
 *   (Don't need to add "Bearer " prefix - Swagger does it)
 * 
 *   Step 3: Make Protected API Calls
 *   ─────────────────────────────────
 *   Swagger automatically adds header:
 *   Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
 * 
 * ════════════════════════════════════════════════════════════════
 * 
 * CODE STRUCTURE:
 * ==============
 * 
 * DependencyInjection.cs:
 * ───────────────────────
 * 
 *   AddOpenApiDocument((configure, sp) =>
 *   {
 *       configure.Title = "InfoManager API";
 *       
 *       // ✅ Define JWT security scheme
 *       configure.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme
 *       {
 *           Type = OpenApiSecuritySchemeType.Http,
 *           Scheme = "Bearer",
 *           BearerFormat = "JWT",
 *           Name = "Authorization",
 *           In = OpenApiSecurityApiKeyLocation.Header,
 *           Description = "Enter JWT Bearer token"
 *       });
 *       
 *       // ✅ Apply to all endpoints with [Authorize]
 *       configure.OperationProcessors.Add(
 *           new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
 *   });
 * 
 * ════════════════════════════════════════════════════════════════
 * 
 * KEY POINTS:
 * ==========
 * 
 * ✓ Type.Http (not ApiKey) - follows HTTP Bearer token standard
 * ✓ Scheme = "Bearer" - tells Swagger to prepend "Bearer " to token
 * ✓ BearerFormat = "JWT" - indicates this is a JWT token
 * ✓ AspNetCoreOperationSecurityScopeProcessor - auto-applies to [Authorize]
 * ✓ In = Header - token goes in Authorization header
 * ✓ All endpoints with [Authorize] get the lock icon 🔒
 * 
 * ════════════════════════════════════════════════════════════════
 * 
 * TROUBLESHOOTING:
 * ===============
 * 
 * Q: Authorize button not showing?
 * A: Make sure AddOpenApiDocument in DependencyInjection.cs
 *    is called before app.UseSwaggerUi()
 * 
 * Q: Token not being sent to API?
 * A: Click Authorize button in Swagger UI (top right, blue button)
 *    then enter your JWT token
 * 
 * Q: "Bearer token not recognized"?
 * A: Make sure token hasn't expired, password is correct,
 *    and you're using the full token (no truncation)
 * 
 * ════════════════════════════════════════════════════════════════
 * 
 * FILE CHANGES:
 * ============
 * 
 * 📄 DependencyInjection.cs - Line 45-60
 *    BEFORE (commented out):
 *    /configure.AddSecurity("JWT", new NSwag.OpenApiSecurityScheme { ... });
 *    
 *    AFTER (enabled):
 *    configure.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme { ... });
 *    configure.OperationProcessors.Add(...AspNetCoreOperationSecurityScopeProcessor...);
 * 
 * ════════════════════════════════════════════════════════════════
 * 
 * STATUS: ✅ Complete
 * ===================
 * 
 * Your API now supports JWT testing in Swagger UI!
 * 
 * To test:
 * 1. Run the application: dotnet run
 * 2. Navigate to: https://localhost:5001/api
 * 3. Look for blue "🔓 Authorize" button (top right)
 * 4. Follow the workflow above
 */
