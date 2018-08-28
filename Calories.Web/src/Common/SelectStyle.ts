import { StylesConfig } from "../../node_modules/@types/react-select/lib/styles";
import { CSSProperties } from "../../node_modules/@types/react";

export var SelectStyle: StylesConfig = {
   option: (base: CSSProperties, state: any) =>
   ({
        ...base,
        color: "black"
   })
}