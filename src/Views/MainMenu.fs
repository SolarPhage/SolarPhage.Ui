module MainMenu

open Messages
open Types
open Main.Types
open Character.Types
open Game.Types
open Templates.Shared
open Templates.Table
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

let createGamesCells (game : Game) (dispatch: MainMessage -> unit) : seq<ReactElement> = 
    [
        Html.tableCell [ 
            Html.a [
                prop.text $"{game.GameId}"
                prop.onClick (fun _ -> dispatch <| LoadPage (ActiveGameMenu, GameMsg(LoadGame(game.GameId, Loading))))
            ]
        ]
        Html.tableCell [ prop.text $"{game.MaxFloor}"]
    ]

let createCharactersCells (character : Character) (dispatch: MainMessage -> unit) : seq<ReactElement> = 
    [
        Html.tableCell [ 
            Html.a [
                prop.text $"{character.CharacterId}"
                prop.onClick (fun _ -> dispatch <| LoadPage (CharacterSelect, CharacterMsg(LoadCharacter(character.UserId, Loading))))
            ]
        ]
        Html.tableCell [ prop.text $"{character.UserId}"]
    ]

let createTableColumnDiv (children : seq<ReactElement>) = 
    Html.div [
        prop.className "column is-half" 
        prop.children children
    ]

let content (state : State) (dispatch: MainMessage -> unit) = 
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
                        state.GameState.Games
                        |> Seq.map (fun x -> createGameTableRow <| createGamesCells x dispatch))
                ]
            ]

            createTableColumnDiv [
                createTable [
                    createTableHeaders ["Name"; "Level"]
                    createTableBody (
                        state.CharacterState.Characters
                        |> Seq.map (fun x -> createGameTableRow <| createCharactersCells x dispatch))
                ]
            ]
        ]
    ]

let footer (dispatch: MainMessage -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CreateCharacter)
            prop.text "Create Character"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CreateGame)
            prop.text "Create Game"
        ]
    ]

let render (state : State) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter (content state dispatch) (footer dispatch)