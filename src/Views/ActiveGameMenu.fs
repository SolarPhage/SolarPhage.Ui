module ActiveGameMenu

open App.Types
open Feliz

let render (state : Model) (dispatch: Msg -> unit) = 
    Html.div [
        prop.className "buttons"
        prop.children [
            Html.div [
                Html.ul [
                    for game in state.Games -> 
                        Html.li [ prop.text $"{ game.GameId } - { game.MaxFloor }" ]
                ]
            ]

            Html.div [
                Html.button [
                    prop.className[ "button" ]
                    prop.onClick (fun _ -> dispatch <| ChangePage TownMenu)
                    prop.text "Join"
                ]
                
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
        ]
    ]