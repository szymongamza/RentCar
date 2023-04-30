# RentCar.API
To build:
1. Clone repo
2. Make sure that you have Node.js and dotnet sdk 7.0
3. Open .sln in Visual Studio
4. Run http configuration
5. Open RentCar.UI in console or VS Code
6. Run in console command: npm start

To add migration:
`
dotnet ef migrations add VehicleModelProperties --project .\RentCar.Infrastructure\RentCar.Infrastructure.csproj --startup-project .\RentCar.API\RentCar.API.csproj
`

Podjête decyzje: