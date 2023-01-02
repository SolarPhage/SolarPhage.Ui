module Main.Types

open Types

type Item = {
    Id: int
    Name: string
}

type CharacterInventoryItem = {
    Item : Item
    Count : int
}

type CombatState = { CombatId : int; PlayerHp : int }
type DungeonInfo = { DungeonId: int; Level : int }
type InventoryUpdate = {
    CharacterId : int
    ItemId : int
    Amount : int
    Cost : int
}
type ShopItem = {
    ItemInfo : Item
    AmountForSale : int
    CostPerItem : int
}

type State = { 
    Count : int
    CurrentPage : Page
    Dungeon : DungeonInfo
    ShopItems : ShopItem list
    GameState : Game.Types.GameState
    CharacterState : Character.Types.CharacterState}