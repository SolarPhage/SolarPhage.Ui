module TableTemplate

open Feliz

let createTableHeaders (headers : string list) = 
    Html.tableRow 
        (headers |> Seq.map (fun x -> Html.tableHeader [ prop.text x]))

let createGameTableRow (cells : seq<ReactElement>) = 
    Html.tableRow cells

let createTableBody (rows : seq<ReactElement>) = 
    Html.tableBody rows

let createTable (children : seq<ReactElement>) = 
    Html.table [
        prop.className "table is-hoverable is-fullwidth"
        prop.children children
    ]