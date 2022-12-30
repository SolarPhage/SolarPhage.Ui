module App.Types.Game

type Game = { GameId : int; MaxFloor : int }

type GameState = {
    Game : Game
    Games : Game list 
}

type Msg = 
    | LoadGame of (int * Shared.DataResult<Game>)
    | LoadGames of Shared.DataResult<Game list>
    | FailedToLoadGame of exn