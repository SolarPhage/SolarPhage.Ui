module App.Types

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
    | Increment of string
    | Decrement of exn
    | ChangePage of Page

type Model = 
    { Count : int; CurrentPage : Page }