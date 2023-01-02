module Messages

open Types
open Character.Types
open Game.Types

type CharacterMessage = 
    | ClearCharacter
    | LoadCharacter of (string * DataResult<Character>)
    | LoadCharacters of DataResult<Character list>
    | SubmitCharacter
    | SubmitCharacterResponse of (int * DataResult<string>)
    | UpdateCharacter of Character
    | FailedToLoadCharacter of exn

type GameMessage = 
    | LoadGame of (int * DataResult<Game>)
    | LoadGames of DataResult<Game list>
    | FailedToLoadGame of exn

type MainMessage = 
    | ChangePage of Page
    | LoadPage of (Page * MainMessage)
    // | LoadDungeon of (int * DataResult<DungeonInfo>)
    // | LoadShop of (DataResult<ShopItem list>)
    | CharacterMsg of CharacterMessage
    | GameMsg of GameMessage
    | FailedToLoad of exn