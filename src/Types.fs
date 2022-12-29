module App.Types

type Game = { GameId : int; MaxFloor : int }

type Item = {
    Id: int
    Name: string
}

type CharacterInventoryItem = {
    Item : Item
    Count : int
}

type Character = {
    CharacterId: int
    UserId: string
    // Name: string
    // Level: int
    // Enabled: bool
    // Inventory: CharacterInventoryItem list
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

type DataResult<'t> = 
    | Loading
    | Result of 't

type Msg = 
    | ChangePage of Page
    | LoadPage of (Page * Msg)
    | ClearCharacter
    | LoadCharacter of (string * DataResult<Character>)
    | LoadCharacters of DataResult<Character list>
    | SubmitCharacter
    | SubmitCharacterResponse of (int * DataResult<string>)
    | UpdateCharacter of Character
    | LoadDungeon of (int * DataResult<DungeonInfo>)
    | LoadGame of (int * DataResult<Game>)
    | LoadGames of DataResult<Game list>
    | LoadShop of (DataResult<ShopItem list>)
    | FailedToLoad of exn

type State = { 
    Count : int
    CurrentPage : Page
    Character : Character
    Characters : Character list
    Dungeon : DungeonInfo
    Game : Game
    Games : Game list 
    ShopItems : ShopItem list}