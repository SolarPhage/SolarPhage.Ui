module MainMenu

open App.Types
open SharedTemplate
open Feliz

let content (state : Model) (dispatch: Msg -> unit) = 
    [
        Html.div [
            prop.className "columns"
            prop.children [
                Html.div [
                    prop.className "column is-half has-text-centered"
                    prop.children [
                        Html.h2 "Games"
                    ]
                ]
                Html.div [
                    prop.className "column is-half has-text-centered"
                    prop.children [
                        Html.h2 "Characters"
                    ]
                ]
            ]
        ]

        Html.div [
            prop.className "columns"
            prop.children [
                Html.div [
                    prop.className "column is-half"
                    prop.children [
                        Html.table [
                            prop.className "table is-hoverable is-fullwidth"
                            prop.children [
                                Html.tableRow [
                                    Html.tableHeader [ prop.text "Game ID"]
                                    Html.tableHeader [ prop.text "Max Floor"]
                                ]
                                Html.tableBody [
                                    for game in state.Games ->
                                        Html.tableRow [
                                            Html.tableCell [ 
                                                Html.a [
                                                    prop.text $"{game.GameId}"
                                                    prop.onClick (fun _ -> dispatch <| ChangePage (ActiveGameMenu game.GameId))
                                                ]
                                            ]
                                            Html.tableCell [ prop.text $"{game.MaxFloor}"]
                                        ]
                                ]
                            ]
                        ]
                    ]
                ]
                Html.div [
                    prop.className "column is-half"
                    prop.children [
                        Html.table [
                            prop.className "table is-hoverable is-fullwidth"
                            prop.children [
                                Html.tableRow [
                                    Html.tableHeader [ prop.text "Name"]
                                    Html.tableHeader [ prop.text "Level"]
                                ]
                                Html.tableBody [
                                    for character in state.Characters ->
                                        Html.tableRow [
                                            Html.tableCell [ 
                                                Html.a [
                                                    prop.text $"{character.Name}"
                                                    prop.onClick (fun _ -> dispatch <| ChangePage (CharacterSelect character.Id))
                                                ]
                                            ]
                                            Html.tableCell [ prop.text $"{character.Level}"]
                                        ]
                                ]
                            ]
                        ]
                    ]
                ]                
            ]
        ]
    ]

let footer (dispatch: Msg -> unit) = 
    [
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

let render (state : Model) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state dispatch) (footer dispatch)