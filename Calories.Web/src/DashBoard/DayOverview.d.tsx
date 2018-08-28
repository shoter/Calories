namespace DayOverview
{
    export interface Props extends DashboardComponent.Props
    {
        calories: Number;
        allowedIntakeLeft: Number;
        exerciseCalories: Number;
        weight?: Number;
        date: Date;
    }
}
