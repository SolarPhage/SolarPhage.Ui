module App.Types.Character

type Character = {
    CharacterId: int
    UserId: string
    // Name: string
    // Level: int
    // Enabled: bool
    // Inventory: CharacterInventoryItem list
}

type CharacterState = {
    Character : Character
    Characters : Character list
}

type Msg = 
    | ClearCharacter
    | LoadCharacter of (string * Shared.DataResult<Character>)
    | LoadCharacters of Shared.DataResult<Character list>
    | SubmitCharacter
    | SubmitCharacterResponse of (int * Shared.DataResult<string>)
    | UpdateCharacter of Character
    | FailedToLoadCharacter of exn