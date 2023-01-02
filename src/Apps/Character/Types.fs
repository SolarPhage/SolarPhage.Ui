module Character.Types

open Types

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