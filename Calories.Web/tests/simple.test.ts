
function calc(a : number, b: number) 
{
    return a + b;
};

describe("Calculator", function() {

    it("Calculates !", function() {
        expect(
            calc(1, 2)
        ).toBe(3);
    });
});