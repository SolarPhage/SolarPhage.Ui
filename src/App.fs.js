import { createAtom } from "./fable_modules/fable-library.3.7.20/Util.js";
import { printf, toText } from "./fable_modules/fable-library.3.7.20/String.js";

export let count = createAtom(0);

export const myButton = document.querySelector(".my-button");

myButton.onclick = ((_arg) => {
    let arg;
    count(count() + 3, true);
    myButton.innerText = ((arg = (count() | 0), toText(printf("You clicked: %i time(s)"))(arg)));
});

