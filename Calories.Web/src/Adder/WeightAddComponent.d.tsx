namespace WeightAddComponent
{
    export interface Props extends DashboardComponent.Props
    {

    }

    export interface State extends DashboardComponent.State
    {
        weightInput: string,
        weight: Number,
        hasWeightToday: Boolean
    }
}