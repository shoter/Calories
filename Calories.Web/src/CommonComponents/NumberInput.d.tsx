namespace NumberInput {
    export interface Props {
        onNumberChange: (number? :Number) => void;
        placeholder?: string;
        value?: Number
    }

    export interface State {
        input: string,
        lastNumber?: Number
    }
}