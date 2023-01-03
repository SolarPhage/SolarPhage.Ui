module Inventory.Types

open Item.Types

type InventoryUpdate = {
    CharacterId : int
    ItemId : int
    Amount : int
    Cost : int
}

type CharacterInventoryItem = {
    Item : Item
    Count : int
}