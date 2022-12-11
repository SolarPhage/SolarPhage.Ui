module TownMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage ShopMenu)
            prop.text "Shop"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage DungeonMenu)
            prop.text "Dungeon"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage MainMenu)
            prop.text "Quit"
        ]
    ]