module App.Types

type Game = { GameId : int; MaxFloor : int }

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
    | LoadGames
    | LoadGamesCompleted of Game list
    | FailedToLoad of exn

type Model = 
    { Count : int; CurrentPage : Page; Games : Game list }