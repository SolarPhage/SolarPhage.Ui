module SharedTemplate

open Feliz

let renderMainContent (children : seq<ReactElement>) = 
    Html.div [
        prop.className "mainContent"
        prop.children children
    ]

let renderFooter (children : seq<ReactElement>) = 
    Html.footer [
        Html.div [
            prop.className "buttons is-centered"
            prop.children children
        ]
    ]

let renderMainContentAndFooter (contentChildren : seq<ReactElement>) (footerChildren : seq<ReactElement>) = 
    Html.div [
        renderMainContent contentChildren
        renderFooter footerChildren
    ]