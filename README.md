# RentCar.API
Web app for renting Tesla cars in Mallorca. Few locations (Palma Airport, Palma City Center, Alcudia and Manacor) and people can rent and return the cars at any one of them. Possibility to rent all available passenger Tesla models.

## Za�o�enia / Decyzje:
1. Dostarczenie MVP spe�niaj�cego wymogi zadania, pomini�cie funkcjonalno�ci takich jak logowanie, rejestracja czy autoryzacja.
2. Z racji bliskich odleg�o�ci biur, ka�dy samoch�d mo�e zosta� wynaj�ty w ka�dym biurze niezale�nie od poprzedniej rezerwacji samochodu. Narzucenie sta�ego odst�pu czasowego mi�dzy rezerwacjami (2h)
3. Koszt liczony od ka�dej rozpocz�tej doby
4. Tylko przyk�adowe unit testy przy u�yciu xUnit i Moq
5. React'a z Typescript'em

## How to run:
Make sure, that u have Docker and Docker Compose: https://docs.docker.com/compose/install/
1. `git clone https://github.com/szymongamza/RentCar.git`  
2. `cd RentCar`  
3. `docker compose up`  

React app will run at: http://localhost:3000/  
API Swagger will be at: http://localhost:5245/swagger/index.html
## Screenshots:
![](./Screenshots/Home.png) 
![](./Screenshots/OFfices.png) 
![](./Screenshots/VehiclesSearch.png) 
![](./Screenshots/Booking.png) 

