import chai from 'chai'
import chaiEnzyme from 'chai-enzyme'
import {configure} from "enzyme"
import Adapter from 'enzyme-adapter-react-16';

var assert = chai.assert;    // Using Assert style
var expect = chai.expect;    // Using Expect style
var should = chai.should();  // Using Should style
chai.use(chaiEnzyme()) // Note the invocation at the ein
configure({ adapter: new Adapter() })

export {expect, assert, should}