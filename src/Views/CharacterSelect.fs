module CharacterSelect

open App.Types
open SharedTemplate
open Feliz

let content (state : State) = 
    [
        Html.h1 [
            prop.text state.Character.CharacterId
        ]
        Html.h1 [
            prop.text state.Character.UserId
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

let render (state : State) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)
