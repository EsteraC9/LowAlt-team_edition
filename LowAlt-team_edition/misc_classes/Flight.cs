namespace LowAlt_team_edition.misc_classes;

public abstract class Flight
{
    /// <summary>
    /// the unique id of the flight
    /// </summary>
    public string FlightId { get; init; }

    /// <summary>
    /// the route the flight will do
    /// </summary>
    public Ruta Route { get; set; }

    /// <summary>
    /// the departure time, in HH:mm
    /// </summary>
    public TimeOnly DepartureTime { get; set; }

    /// <summary>
    /// the duration of the flight in minutes
    /// </summary>
    public int FlightTime { get; set; }

    /// <summary>
    /// the number of seats of the plane
    /// </summary>
    public int Seats { get; init; }

    /// <summary>
    /// the number of empty seats
    /// </summary>
    public int AvailableSeats { get; set; }

    public List<Reservation> Reservations { get; init; }

    public Flight(string flightId, Ruta route, TimeOnly departureTime, int flightTime, int seats, int availableSeats)
    {
        FlightId = flightId;
        Route = route;
        DepartureTime = departureTime;
        FlightTime = flightTime;
        Seats = seats;
        AvailableSeats = availableSeats;

        Reservations = new List<Reservation>();
    }

    public Flight(MockFlight mockFlight, Ruta route) {
        FlightId = mockFlight.flightId;
        DepartureTime = mockFlight.departureTime;
        FlightTime = mockFlight.flightTime;
        Seats = mockFlight.seats;
        AvailableSeats = mockFlight.availableSeats;

        Route = route;

        Reservations = new List<Reservation>();
    }

    /// <summary>
    /// adds a reservation to the flight
    /// </summary>
    public void AddReservation(Reservation reservation) => Reservations.Add(reservation);

    /// <summary>
    /// calculates the total revenue from the flight
    /// </summary>
    public double GetRevenue() => GetSeatPrice() * (Seats - AvailableSeats);

    /// <summary>
    /// Calculeaza numarul de locuri rezervate intr-un zbor
    /// </summary>
    public int LocuriRezervate()
    {
        return Seats - AvailableSeats;
    }

    /// <summary>
    /// calculates the proce of a ticket
    /// </summary>
    public abstract double GetSeatPrice();

    public override string ToString()
    {
        return
            $"ID Zbor: {FlightId}\nRuta: {Route}\nOra de plecare: {DepartureTime}\nDurata Zbor: {FlightTime} minute\nLocuri: {Seats}\nLocuri disponibile: {AvailableSeats}";
    }
    
    
    
    
}
