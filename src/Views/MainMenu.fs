module MainMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        prop.className "buttons"
        prop.children [
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
    ]