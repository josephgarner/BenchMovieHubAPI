using MovieHubAPI.Database;
using MovieHubAPI.Database.Entities;

namespace MovieHubApiUnitTests.Fixtures;

public class Seeding
{
    public static void InitDb(MovieHubContext db)
    {
        db.Movie.AddRange(GetMovies());
        db.Cinema.AddRange(GetCinemas());
        db.MovieCinema.AddRange(GetMovieCinemas());
        db.SaveChanges();
    }

    private static List<Movie> GetMovies()
    {
        return
        [
            new Movie("Star Wars: The Phantom Menace (Episode I)", DateTime.Parse("1999-05-19"),
                "Action, Adventure, Fantasy, Live Action, Science Fiction", 8160,
                "Experience the heroic action and unforgettable adventures of Star Wars: Episode I - The Phantom Menace. See the first fateful steps in the journey of Anakin Skywalker. Stranded on the desert planet Tatooine after rescuing young Queen Amidala from the impending invasion of Naboo, Jedi apprentice Obi-Wan Kenobi and his Jedi Master Qui-Gon Jinn discover nine-year-old Anakin, who is unusually strong in the Force. Anakin wins a thrilling Podrace and with it his freedom as he leaves his home to be trained as a Jedi. The heroes return to Naboo where Anakin and the Queen face massive invasion forces while the two Jedi contend with a deadly foe named Darth Maul. Only then do they realize the invasion is merely the first step in a sinister scheme by the re-emergent forces of darkness known as the Sith.",
                "George Lucas", "PG", "0120915"),

            new Movie("Star Wars: Attack of the Clones (Episode II)", DateTime.Parse("2002-05-16"),
                "Action, Adventure, Fantasy, Live Action, Science Fiction", 8520,
                "Watch the seeds of Anakin Skywalker's transformation take root in Star Wars: Episode II - Attack of the Clones. Ten years after the invasion of Naboo, the galaxy is on the brink of civil war. Under the leadership of a renegade Jedi named Count Dooku, thousands of solar systems threaten to break away from the Galactic Republic. When an assassination attempt is made on Senator Padmé Amidala, the former Queen of Naboo, twenty-year-old Jedi apprentice Anakin Skywalker is assigned to protect her. In the course of his mission, Anakin discovers his love for Padmé as well as his own darker side. Soon, Anakin, Padmé, and Obi-Wan Kenobi are drawn into the heart of the Separatist movement and the beginning of the Clone Wars.",
                "George Lucas", "PG-13", "0121765"),

            new Movie("Star Wars: Revenge of the Sith (Episode III)", DateTime.Parse("2005-05-19"),
                "Action, Adventure, Fantasy, Live Action, Science Fiction", 8399,
                "Discover the true power of the dark side in Star Wars: Episode III - Revenge of the Sith. Years after the onset of the Clone Wars, the noble Jedi Knights lead a massive clone army into a galaxy-wide battle against the Separatists. When the sinister Sith unveil a thousand-year-old plot to rule the galaxy, the Republic crumbles and from its ashes rises the evil Galactic Empire. Jedi hero Anakin Skywalker is seduced by the dark side of the Force to become the Emperor's new apprentice – Darth Vader. The Jedi are decimated, as Obi-Wan Kenobi and Jedi Master Yoda are forced into hiding.",
                "George Lucas", "PG-13", "0121766")
        ];
    }

    private static List<Cinema> GetCinemas()
    {
        return
        [
            new Cinema("Cinemarvel","72 Bette McNee Street, Sandy Gully, NSW 2729"),
            new Cinema("Moviemania","7 Old Tenterfield Road, Old Bonalbo, NSW 2469"),
            new Cinema("BigScreen Bliss","93 Creek Street, Kooralgin, Queensland 4402")

        ];
    }

    private static List<MovieCinema> GetMovieCinemas()
    {
        return
        [
            new MovieCinema(1,1,DateTime.Parse("2024-12-31"),(decimal)24.5),
            new MovieCinema(1,2,DateTime.Parse("2024-12-31"),(decimal)22.75),
            new MovieCinema(2,2,DateTime.Parse("2024-12-31"),(decimal)21.25),
            new MovieCinema(2,3,DateTime.Parse("2024-12-31"),(decimal)25.75),
            new MovieCinema(3,1,DateTime.Parse("2024-12-31"),(decimal)28.0),
            new MovieCinema(3,3,DateTime.Parse("2024-12-31"),(decimal)25.0)
        ];
    }
}
