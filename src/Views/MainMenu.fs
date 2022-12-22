module MainMenu

open App.Types
open SharedTemplate
open Feliz

let content = 
    [
        Html.div [
            prop.text "test"
        ]
    ]

let footer (dispatch: Msg -> unit) = 
    [
        Html.label [
            prop.onClick (fun _ -> dispatch <| ChangePage ActiveGameMenu)
            prop.text "Active Games"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CreateCharacter)
            prop.text "Create Character"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CreateCharacter)
            prop.text "Create Game"
        ]
    ]

let render (dispatch: Msg -> unit) = 
    renderMainContentAndFooter content (footer dispatch)