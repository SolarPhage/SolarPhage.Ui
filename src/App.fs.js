import * as main from "./scss/main.scss";
import { CharacterState, Character } from "./Apps/Character/Types.fs.js";
import { ofArray, singleton, empty } from "./fable_modules/fable-library.3.7.20/List.js";
import { DungeonState, DungeonInfo } from "./Apps/Dungeon/Types.fs.js";
import { GameState, Game } from "./Apps/Game/Types.fs.js";
import { ShopState } from "./Apps/Shop/Types.fs.js";
import { DataResult$1, Page } from "./Apps/Types.fs.js";
import { State } from "./Apps/Main/Types.fs.js";
import { Cmd_map, Cmd_none, Cmd_batch } from "./fable_modules/Fable.Elmish.4.0.0/cmd.fs.js";
import { CharacterMessage, MainMessage, GameMessage } from "./Apps/Messages.fs.js";
import { update as update_1 } from "./Apps/Character/App.fs.js";
import { update as update_2 } from "./Apps/Dungeon/App.fs.js";
import { update as update_3 } from "./Apps/Game/App.fs.js";
import { update as update_4 } from "./Apps/Shop/App.fs.js";
import { render as render_1 } from "./Apps/Character/Views/CharacterSelect.fs.js";
import { render as render_2 } from "./Apps/Combat/Views/CombatMenu.fs.js";
import { render as render_3 } from "./Apps/Combat/Views/CombatPhotocastsMenu.fs.js";
import { render as render_4 } from "./Apps/Combat/Views/CombatPotionMenu.fs.js";
import { render as render_5 } from "./Apps/Character/Views/CreateCharacter.fs.js";
import { render as render_6 } from "./Apps/Game/Views/CreateGame.fs.js";
import { render as render_7 } from "./Apps/Dungeon/Views/DungeonMenu.fs.js";
import { render as render_8 } from "./Apps/Game/Views/GameCharacterMenu.fs.js";
import { render as render_9 } from "./Apps/Game/Views/GameInventoryMenu.fs.js";
import { render as render_10 } from "./Apps/Game/Views/GameInventoryPhotocastMenu.fs.js";
import { render as render_11 } from "./Apps/Game/Views/GameMenu.fs.js";
import { render as render_12 } from "./Apps/Game/Views/GamePhotocastMenu.fs.js";
import { render as render_13 } from "./Apps/Main/Views/MainMenu.fs.js";
import { render as render_14 } from "./Apps/Combat/Views/PostCombatMenu.fs.js";
import { render as render_15 } from "./Apps/Shop/Views/ShopBuyItem.fs.js";
import { render as render_16 } from "./Apps/Shop/Views/ShopInventoryItem.fs.js";
import { render as render_17 } from "./Apps/Shop/Views/ShopMenu.fs.js";
import { render as render_18 } from "./Apps/Town/Views/TownMenu.fs.js";
import { render as render_19 } from "./Apps/Game/Views/ActiveGameMenu.fs.js";
import { ProgramModule_mkProgram, ProgramModule_run } from "./fable_modules/Fable.Elmish.4.0.0/program.fs.js";
import { Program_withReactSynchronous } from "./fable_modules/Fable.Elmish.React.3.0.1/react.fs.js";


export const initCharacterState = new CharacterState(new Character(0, ""), empty());

export const initDungeonState = new DungeonState(new DungeonInfo(5, 1));

export const initGameState = new GameState(new Game(5, 5), empty());

export const initShopState = new ShopState(empty());

export function init() {
    return [new State(0, new Page(0), initDungeonState, initShopState, initGameState, initCharacterState), Cmd_batch(ofArray([singleton((dispatch) => {
        dispatch(new MainMessage(4, new GameMessage(1, new DataResult$1(0))));
    }), singleton((dispatch_1) => {
        dispatch_1(new MainMessage(2, new CharacterMessage(2, ["230598sfljf", new DataResult$1(0)])));
    })]))];
}

export function update(msg, state) {
    switch (msg.tag) {
        case 0: {
            const page_1 = msg.fields[0];
            return [new State(state.Count, page_1, state.DungeonState, state.ShopState, state.GameState, state.CharacterState), Cmd_none()];
        }
        case 2: {
            const characterMsg = msg.fields[0];
            const patternInput = update_1(characterMsg, state.CharacterState);
            const cmd = patternInput[1];
            const cState = patternInput[0];
            const appCmd = Cmd_map((x) => (new MainMessage(2, x)), cmd);
            return [new State(state.Count, state.CurrentPage, state.DungeonState, state.ShopState, state.GameState, cState), appCmd];
        }
        case 3: {
            const msg_2 = msg.fields[0];
            const patternInput_1 = update_2(msg_2, state.DungeonState);
            const dState = patternInput_1[0];
            const cmd_1 = patternInput_1[1];
            const appCmd_1 = Cmd_map((x_1) => (new MainMessage(3, x_1)), cmd_1);
            return [new State(state.Count, state.CurrentPage, dState, state.ShopState, state.GameState, state.CharacterState), appCmd_1];
        }
        case 4: {
            const gameMsg = msg.fields[0];
            const patternInput_2 = update_3(gameMsg, state.GameState);
            const gState = patternInput_2[0];
            const cmd_2 = patternInput_2[1];
            const appCmd_2 = Cmd_map((x_2) => (new MainMessage(4, x_2)), cmd_2);
            return [new State(state.Count, state.CurrentPage, state.DungeonState, state.ShopState, gState, state.CharacterState), appCmd_2];
        }
        case 5: {
            const msg_3 = msg.fields[0];
            const patternInput_3 = update_4(msg_3, state.ShopState);
            const sState = patternInput_3[0];
            const cmd_3 = patternInput_3[1];
            const appCmd_3 = Cmd_map((x_3) => (new MainMessage(5, x_3)), cmd_3);
            return [new State(state.Count, state.CurrentPage, state.DungeonState, sState, state.GameState, state.CharacterState), appCmd_3];
        }
        case 6: {
            const error = msg.fields[0];
            return [state, Cmd_none()];
        }
        default: {
            const page = msg.fields[0][0];
            const command = msg.fields[0][1];
            return [new State(state.Count, page, state.DungeonState, state.ShopState, state.GameState, state.CharacterState), singleton((dispatch) => {
                dispatch(command);
            })];
        }
    }
}

export function render(state, dispatch) {
    const matchValue = state.CurrentPage;
    switch (matchValue.tag) {
        case 1: {
            return render_1(state.CharacterState, dispatch);
        }
        case 15: {
            return render_2(dispatch);
        }
        case 17: {
            return render_3(dispatch);
        }
        case 16: {
            return render_4(dispatch);
        }
        case 3: {
            return render_5(state.CharacterState, dispatch);
        }
        case 4: {
            return render_6(dispatch);
        }
        case 14: {
            return render_7(state.DungeonState, dispatch);
        }
        case 10: {
            return render_8(dispatch);
        }
        case 12: {
            return render_9(dispatch);
        }
        case 13: {
            return render_10(dispatch);
        }
        case 9: {
            return render_11(dispatch);
        }
        case 11: {
            return render_12(dispatch);
        }
        case 0: {
            return render_13(state, dispatch);
        }
        case 18: {
            return render_14(dispatch);
        }
        case 7: {
            return render_15(dispatch);
        }
        case 8: {
            return render_16(dispatch);
        }
        case 6: {
            return render_17(state.ShopState, dispatch);
        }
        case 5: {
            return render_18(state, dispatch);
        }
        default: {
            return render_19(state.GameState, dispatch);
        }
    }
}

ProgramModule_run(Program_withReactSynchronous("elmish-app", ProgramModule_mkProgram(init, update, render)));

