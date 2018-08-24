namespace MySelect
{
    export interface Props
    {
        options?: MySelect.Option[],
        selectedValue?: string,
        onSelect?: (value: string) => void;
    }

    export interface State
    {
        selectedValue?: string
    }

    export interface Option
    {
        value: string,
        text: string

    }
}
