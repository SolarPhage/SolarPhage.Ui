module CharacterSelect

open App.Types
open SharedTemplate
open Feliz

let content (state : Model) = 
    [
        Html.h1 [
            prop.text state.Character.Name
        ]
        Html.h1 [
            prop.text state.Character.Inventory.[0].Item.Name
        ]
    ]

let footer (dispatch: Msg -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.text "Delete"
        ]
        
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage MainMenu)
            prop.text "Back"
        ]
    ]

let render (state : Model) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)
