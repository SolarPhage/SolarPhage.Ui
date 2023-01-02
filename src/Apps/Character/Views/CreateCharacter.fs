module Character.Views.CreateCharacter

open Messages
open Types
open Character.Types
open Templates.Shared
open Feliz

let updateUserId (state : CharacterState) (userId : string) = 
    { state.Character with UserId = userId } 

let content (state : CharacterState) (dispatch: MainMessage -> unit) = 
    [
        Html.div [
             Html.input [
                prop.placeholder "user id"
                prop.onChange (fun x -> dispatch <| CharacterMsg (UpdateCharacter (updateUserId state x)))
             ]
        ]
    ]

let footer (dispatch: MainMessage -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| CharacterMsg (SubmitCharacter))
            prop.text "Create"
        ]
        
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage MainMenu)
            prop.text "Back"
        ]
    ]

let render (state : CharacterState) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter (content state dispatch) (footer dispatch)