namespace Dashboard
{
    export interface DaySummary
    {
        calories: number,
        weight? : number,
        caloriesIntakeLeft: number,
        exerciseCalories: number
        date: Date,
        text: string
    }
    export interface Props
    {

    }

    export interface State
    {
        summaries: Dashboard.DaySummary[]
        
    }
}
