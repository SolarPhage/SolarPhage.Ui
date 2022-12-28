module MainMenu

open App.Types
open SharedTemplate
open TableTemplate
open Feliz

let createColumnsDiv (children : seq<ReactElement>) = 
    Html.div [
        prop.className "columns"
        prop.children children
    ]

let createHeaderColumnDiv (title : string) = 
    Html.div [
        prop.className "column is-half has-text-centered" 
        prop.children [
            Html.h2 title
        ]
    ]

let createGamesCells (game : Game) (dispatch: Msg -> unit) : seq<ReactElement> = 
    [
        Html.tableCell [ 
            Html.a [
                prop.text $"{game.GameId}"
                prop.onClick (fun _ -> dispatch <| LoadPage (ActiveGameMenu, LoadGame(game.GameId, Loading)))
            ]
        ]
        Html.tableCell [ prop.text $"{game.MaxFloor}"]
    ]

let createCharactersCells (character : Character) (dispatch: Msg -> unit) : seq<ReactElement> = 
    [
        Html.tableCell [ 
            Html.a [
                prop.text $"{character.CharacterId}"
                prop.onClick (fun _ -> dispatch <| LoadPage (CharacterSelect, LoadCharacter(character.UserId, Loading)))
            ]
        ]
        Html.tableCell [ prop.text $"{character.UserId}"]
    ]

let createTableColumnDiv (children : seq<ReactElement>) = 
    Html.div [
        prop.className "column is-half" 
        prop.children children
    ]

let content (state : State) (dispatch: Msg -> unit) = 
    [
        createColumnsDiv [
            createHeaderColumnDiv "Games"
            createHeaderColumnDiv "Characters"
        ]

        createColumnsDiv [
            createTableColumnDiv [
                createTable  [
                    createTableHeaders ["Game ID"; "Max Floor"]
                    createTableBody (
                        state.Games
                        |> Seq.map (fun x -> createGameTableRow <| createGamesCells x dispatch))
                ]
            ]

            createTableColumnDiv [
                createTable [
                    createTableHeaders ["Name"; "Level"]
                    createTableBody (
                        state.Characters
                        |> Seq.map (fun x -> createGameTableRow <| createCharactersCells x dispatch))
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

let render (state : State) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state dispatch) (footer dispatch)