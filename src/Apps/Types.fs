module Types

type DataResult<'t> = 
    | Loading
    | Result of 't

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