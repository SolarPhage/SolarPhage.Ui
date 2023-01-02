module Game.Types

type Game = { GameId : int; MaxFloor : int }

type GameState = {
    Game : Game
    Games : Game list 
}