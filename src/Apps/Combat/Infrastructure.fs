module Combat.Infrastructure

open Fable.SimpleHttp
open Fable.SimpleJson
open Types

let combatUrl = $"{Api.apiUrl}/combat"
let combatIdUrl id = $"{Api.apiUrl}/combat/{id}"

let postCombatState state = 
    async {
        let requestData = Json.stringify state
        let! (statusCode, responseText) = Http.post combatUrl requestData

        let combatState = Json.parseAs<CombatState> responseText

        return (statusCode, Result combatState)
    }

let getCombat (combatId : int) = 
    async {
        let! (statusCode, responseText) = Http.get <| combatIdUrl combatId

        let combatState = Json.parseAs<CombatState> responseText

        return (combatId, Result combatState)
    }