namespace Menu 
{
    export interface Link
    {
        to: string,
        text: string
    }

    export interface Props
    {
        links: Link[]
    }

    export interface State
    {
        isExpanded: boolean
    }
}