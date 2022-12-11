module MainMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.label [
            prop.onClick (fun _ -> dispatch <| ChangePage ActiveGameMenu)
            prop.text "Active Games"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage CreateCharacter)
            prop.text "Create Character"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage CreateCharacter)
            prop.text "Create Game"
        ]
    ]