## Exam Preparation

1. Implement an accordion control using JavaScript. The accordion is a list of items that can be expanded or collapsed. It must support adding of items.
    ```js
    var accordion = controls.getAccordion("#accordion-holder");
    accordion.add("Web");
    accordion.add("Desktop");
    accordion.add("Mobile");
    accordion.add("Embedded"); 
    accordion.render();
    ```

2. The accordion items must support nested items, i.e. an item can contain sub items, and each of these sub items can contain sub items of its own, etc… The rules for expanding are the same.
    ```js
    var accordion = controls.getAccordion("#accordion");
    var webItem = accordion.add("Web");

    webItem.add("HTML");
    webItem.add("CSS");
    webItem.add("JavaScript");
    webItem.add("jQuery");
    webItem.add("ASP.NET MVC");

    accordion.add("Desktop");
    accordion.add("Mobile");
    accordion.add("Embedded");

    accordion.render();
    ```

3. When an item is clicked, it should either expand or collapse. If the clicked item is expanded, it should collapse, and if it is collapsed it should expand.
4. When an item is clicked all of its sibling items should collapse, whether the item is collapsed or expanded.
5. Save the accordions items into a localStorage. Serialize the accordion data in a meaningful way, i.e. save only the titles in array of objects.
    ```js
    // Added items to the accordion
    var state = accordion.serialize();
    localStorage.setObject("tracks-accordion", state);
    ```

6. Deserialize a data describing an accordion(serialized in localStorage) and build a new accordion with this data. The original accordion and the new accordion should have exactly the same items, with exactly the same subitems, etc.
    ```js
    var state = localStorage.getObject("tracks-accordion");
    controls.getDeserializedAccordion("#accordion-holder", state);
    ```
    
**The code samples and UI provided are only sample are not mandatory. You are not obligated to use it, but must implement similar functionality.**
