module CreateCharacter

open App.Types
open SharedTemplate
open Feliz

let updateUserId (state : Character.CharacterState) (userId : string) = 
    { state.Character with UserId = userId } 

let content (state : Character.CharacterState) (dispatch: Msg -> unit) = 
    [
        Html.div [
             Html.input [
                prop.placeholder "user id"
                prop.onChange (fun x -> dispatch <| CharacterMsg (Character.UpdateCharacter (updateUserId state x)))
             ]
        ]
    ]

let footer (dispatch: Msg -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| CharacterMsg (Character.SubmitCharacter))
            prop.text "Create"
        ]
        
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage MainMenu)
            prop.text "Back"
        ]
    ]

let render (state : Character.CharacterState) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state dispatch) (footer dispatch)
