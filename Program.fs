// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

type Director = {
    Name : string
    Movies : int
}
// Movie record type
type Movie = {
    Name : string
    RunLength : int
    Genre : Genre
    Director : Director
    IMDBRating : float
}

let coda = {Name = "CODA"; RunLength = 111; Genre = Drama; Director = {Name = "Sian Heder"; Movies = 9}; IMDBRating = 8.1}
let belfast = {Name = "Belfast"; RunLength = 98; Genre = Comedy; Director = {Name = "Kenneth Branagh"; Movies = 23}; IMDBRating = 7.3}
let dontLookUp = {Name = "Don't Look Up"; RunLength = 138; Genre = Comedy; Director = {Name = "Adam McKay"; Movies = 27}; IMDBRating = 7.2}
let driveMyCar = {Name = "Drive My Car"; RunLength = 179; Genre = Drama; Director = {Name = "Ryusuke Hamaguchi"; Movies = 16}; IMDBRating = 7.6}
let dune = {Name = "Dune"; RunLength = 155; Genre = Fantasy; Director = {Name = "Denis Villeneuve"; Movies = 24}; IMDBRating = 8.1}
let kingRichard = {Name = "King Richard"; RunLength = 144; Genre = Sport; Director = {Name = "Reinaldo Marcus Green"; Movies = 15}; IMDBRating = 7.5}
let licoricePizza = {Name = "Licorice Pizza"; RunLength = 133; Genre = Comedy; Director = {Name = "Paul Thomas Anderson"; Movies = 49}; IMDBRating = 7.4}
let nightmareAlley = {Name = "Nightmare Alley"; RunLength = 150; Genre = Thriller; Director = {Name = "Guillermo del Toro"; Movies = 22}; IMDBRating = 7.1}

// Create a list of movies
let oscarMovies = [coda; belfast; dontLookUp; driveMyCar; dune; kingRichard; licoricePizza; nightmareAlley]

let OscarWinners = oscarMovies |> List.filter (fun movie -> movie.IMDBRating > 7.4)

let convertToHours (movie : Movie) =
    let hours = movie.RunLength / 60
    let minutes = movie.RunLength % 60
    if hours = 1 then
        sprintf "%d hour %d minutes" hours minutes
    else if hours > 1 && minutes = 0 then
        sprintf "%d hours" hours
    else if hours > 1 && minutes > 0 then
        sprintf "%d hours %d minutes" hours minutes
    else
        sprintf "%d minutes" minutes

let oscarMoviesWithRunLengthInHours = oscarMovies |> List.map convertToHours

printfn "Probable Oscar Winners:"
OscarWinners |> List.iter (fun movie -> printfn "- %s (%s)" movie.Name (movie.Genre.ToString().ToLower()))

printfn "\nMovie Run Lengths:"
oscarMoviesWithRunLengthInHours |> List.iter (printfn "- %s")

printfn "\nNames of Movies with Lengths:"
oscarMovies |> List.iter (fun movie -> printfn "- %s: %s" movie.Name (convertToHours movie))
