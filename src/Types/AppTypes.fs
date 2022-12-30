module App.Types

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

type Page = 
    | MainMenu
    | CharacterSelect
    | ActiveGameMenu
    | CreateCharacter
    | CreateGame
    | TownMenu
    | ShopMenu
    | ShopBuyItem
    | ShopInventoryItem
    | GameMenu
    | GameCharacterMenu
    | GamePhotocastMenu
    | GameInventoryMenu
    | GameInventoryPhotocastMenu
    | DungeonMenu
    | CombatMenu
    | CombatPotionMenu
    | CombatPhotocastsMenu
    | PostCombatMenu

type Msg = 
    | ChangePage of Page
    | LoadPage of (Page * Msg)
    | LoadDungeon of (int * Types.Shared.DataResult<DungeonInfo>)
    | LoadShop of (Types.Shared.DataResult<ShopItem list>)
    | CharacterMsg of App.Types.Character.Msg
    | GameMsg of App.Types.Game.Msg
    | FailedToLoad of exn

type State = { 
    Count : int
    CurrentPage : Page
    Dungeon : DungeonInfo
    ShopItems : ShopItem list
    GameState : App.Types.Game.GameState
    CharacterState : App.Types.Character.CharacterState}