import React from "react";
import enzyme, {shallow} from "enzyme";
import {expect} from "./setup";
import Dupa from "../src/Dupa";

describe("Dupa component", function() {
    const msg = "test";
    var component:enzyme.ShallowWrapper;

    beforeEach(function() {
        component = shallow(<Dupa message={msg} />);
    });

    it("Displays proper text", function() {
        expect(
            component
        ).to.have.text(msg);
    })

    it("Is not checked at start", function() {
        expect(
            component.find('input')
        ).to.not.be.checked();
    });

    it("Is checked after click", function() {
        component.find("input").simulate("click");

        expect(
            component.find('input')
        ).to.be.checked();
    })

});