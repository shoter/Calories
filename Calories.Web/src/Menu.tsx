import React from "react";
import {Link} from "react-router-dom";
 
export default class Menu extends React.Component<Menu.Props, Menu.State> {
   constructor(props: Menu.Props)
   {
       super(props)

       this.state = {
           isExpanded: false
       };
   }
   
   render() {
        var links = this.props.links
        .map((link: Menu.Link) => ( 
        <Link key={link.to} className="element" to={link.to}>{link.text}</Link>
    ));
        
        return (
            <nav className="expanded">
                <div className="expander element">
                    Expander
                </div>
                {links}
            </nav>
        )
   }
}