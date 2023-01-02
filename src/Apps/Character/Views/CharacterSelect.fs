module Character.Views.CharacterSelect

open Character.Types
open Messages
open Types
open Templates.Shared
open Feliz

let content (state : CharacterState) = 
    [
        Html.h1 [
            prop.text state.Character.CharacterId
        ]
        Html.h1 [
            prop.text state.Character.UserId
        ]
    ]

let footer (dispatch: MainMessage -> unit) = 
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

let render (state : CharacterState) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)