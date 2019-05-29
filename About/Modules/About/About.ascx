﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="About.ascx.cs" Inherits="Profiles.About.Modules.About.About" %>
<div class="pageTabs">
    <asp:Literal runat="server" ID="litTabs"></asp:Literal>
</div>
<div class="aboutText">
    <asp:Panel runat="server" ID="pnlOverview" Visible="false">
        <table>
            <tr>
                <td>
                    <h3>
                        Introduction</h3>
                    <p>
                        Profiles Research Networking Software is a research networking and expertise mining
                        software tool. It not only shows traditional directory information, but also illustrates
                        how each person is connected to others in the broad research community.
                    </p>
                    <p>
                        As you navigate through the website, you will see three types of pages:
                    </p>
                    <p>
                        <asp:Image runat="server" ID="imgProfilesIcon" alt=""></asp:Image>
                        <u>Profile Pages</u>
                        <div style="padding-left: 15px">
                            Each person has a Profile Page that includes his or her name, titles, affiliations,
                            and contact information. Faculty can edit their own profiles, adding publications,
                            awards, narrative, and a photo. Other objects, such as publications, journals, departments,
                            or concepts can have "profiles". This About page is a "profile" of the Profiles
                            Research Networking Software website.
                        </div>
                    </p>
                    <ul>
                        <li style="padding-bottom: 10px"><b>Passive Networks</b> - Passive networks are formed
                            automatically when faculty share common traits such as being in the same department,
                            working in the same building, co-authoring the same paper, or researching the same
                            concepts or topics. A preview of a person's passive networks is shown on the right
                            side of his or her profile.</li>
                        <li><b>Active Networks</b> - Active networks are the ones that you define. When users
                            who login to the website view other people's profiles, they can mark those people
                            as collaborators, advisors, or advisees. In other words, you can build your own
                            network of people that you know. Currently, you can only see the networks that you
                            build. In the future you will be able to share these lists with others. Active networks
                            are shown on your left sidebar.</li>
                    </ul>
                    <br />
                    <p>
                        <asp:Image runat="server" ID="imgNetworkIcon" alt=""/>
                        <u>Network Pages</u><br />
                        <div style="padding-left: 15px">
                            Network Pages show all the people in a particular Passive or Active Network. Networks
                            can also include other types of profiles, not just people. A "concept" network is
                            a list of all the topics a person has written about. There are many ways to display
                            a network other than a simple list, and Profiles offers several types of network
                            visualization tools.</div>
                    </p>
                    <p>
                        <asp:Image runat="server" ID="imgConnectionIcon" alt=""/>
                        <u>Connection Pages</u><br />
                        <div style="padding-left: 15px">
                            Certain Network Pages will include a "Why?" link. These will take you to a Connection
                            Page, which shows why two people or profiles in that network are connected. For
                            example, the Why link in a co-authorship network lists the publications that two
                            people wrote together. The Connection Pages also reveal why certain people appear
                            higher on search results and why particular concepts are highlighted on a person's
                            profile.
                        </div>
                    </p>
                    <h3>
                        Visualizations</h3>
                    <p>
                        Profiles Research Networking Software includes several different ways to view networks,
                        including (from left to right) Concept Clouds, which highlight a person's areas
                        of research; Map Views, which show where a person's co-authors are located; Publication
                        Timelines, which graph the number of publications of different types by year; Radial
                        Network Views, which illustrate clusters of connectivity among related people; and
                        Concept Timelines, which depict how a person's research focus has changed over time.
                    </p>
                    <p>
                        <div align="center">
                            <asp:Image runat="server" ID="imgVis" alt="visualization thumnails"/>
                        </div>
                    </p>
                    <h3>
                        Sharing Data</h3>
                    <p>
                        Profiles Research Networking Software is a Semantic Web application, which means
                        its content can be read and understood by other computer programs. This enables
                        the data in profiles, such as addresses and publications, to be shared with other
                        institutions and appear on other websites. If you click the "Export RDF" link on
                        the left sidebar of a profile page, you can see what computer programs see when
                        visiting a profile. For technical information about how build a computer program
                        that can export data from Profiles Research Networking Software, view the <a href="?tab=data">
                            Sharing Data</a> page.
                    </p>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlFAQ" Visible="false">
        <h3>
            How do I edit my profile?
        </h3>
        <p>
            To edit your profile, click the Edit My Profile link on the sidebar. You might be
            prompted to login. The Edit Menu page lists all the types of content that can be
            included on your profile. They are grouped into categories and listed in the same
            order as they appear when viewing your profile. Click any content type to view/edit
            the items or change the privacy settings. Some types of content are imported automatically
            from other systems, and you cannot edit them through Profiles. They appear with
            a "locked" icon and contain more information when you click them. An example of
            this is data that comes from your Human Resources record, such as affiliation, title,
            mailing address, and email address.
        </p>
        <p>
            To view your profile as others see it, click the View My Profile link on the sidebar.
        </p>
        <h3>
            Why are there missing or incorrect publications in my profile?
        </h3>
        <p>
            Publications are added both automatically from PubMed and manually by faculty themselves.
            Unfortunately, there is no easy way to match articles in PubMed to the profiles
            on this website. The algorithm used to find articles from PubMed attempts to minimize
            the number of publications incorrectly added to a profile; however, this method
            results in some missing publications. Faculty with common names or whose articles
            were written at other institutions are most likely to have incomplete publication
            lists. We encourage all faculty to login to the website and add any missing publications
            or remove incorrect ones.
        </p>
        <h3>
            Can I edit my concepts, co-authors, or list of similar people?
        </h3>
        <p>
            These are derived automatically from the PubMed articles listed with your profile.
            You cannot edit these directly, but you can improve these lists by keeping your
            publications up to date. Please note that it takes up to 24 hours for the system
            to update your concepts, co-authors, and similar people after you have modified
            your publications. Concept rankings and similar people lists are based on algorithms
            that weigh multiple factors, such as how many publications you have in a subject
            area compared to the total number of faculty who have published in that area. Your
            feedback is essential to helping us refine these algorithms. A future version of
            this website will allow users to add custom concepts to their profiles, but these
            will be separate from the automatically derived terms.
        </p>
        <h3>
            Who created Profiles Research Networking Software?
        </h3>
        <p>
            This service is made possible by the Profiles Research Networking Software developed
            under the supervision of Griffin M Weber, MD, PhD, with support from Grant Number
            1 UL1 RR025758-01 to Harvard Catalyst: The Harvard Clinical and Translational Science
            Center from the National Center for Research Resources and support from Harvard
            University and its affiliated academic healthcare centers.
        </p>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlData" Visible="false">
        <h3>
            Sharing Data (Export RDF)</h3>
        <p>
            Profiles Research Networking Software is a Semantic Web application, which means
            its content can be read and understood by other computer programs. This enables
            the data in profiles, such as addresses and publications, to be shared with other
            institutions and appear on other websites. If you click the "Export RDF" link on
            the left sidebar of a profile page, you can see what computer programs see when
            visiting a profile. The section below describes the technical details for building
            a computer program that can export data from Profiles Research Networking Software.
        </p>
        <h3>
            Technical Details</h3>
        <p>
            As a Semantic Web application, Profiles Research Networking Software uses the Resource
            Description Framework (RDF) data model. In RDF, every entity (e.g., person, publication,
            concept) is given a unique URI. (A URI is similar to a URL that you would enter
            into a web browser.) Entities are linked together using "triples" that contain three
            URIs--a subject, predicate, and object. For example, the URI of a Person can be
            connected to the URI of a Concept through a predicate URI of hasResearchArea. Profiles
            Research Networking Software contains millions of URIs and triples. Semantic Web
            applications use an ontology, which describes the classes and properties used to
            define entities and link them together. Profiles Research Networking Software uses
            the VIVO Ontology, which was developed as part of an NIH-funded grant to be a standard
            for academic and research institutions. A growing number of sites around the world
            are adopting research networking platforms that use the VIVO Ontology. Because RDF
            can link different triple-stores that use the same ontology, software developers
            are able to create tools that span multiple institutions and data sources. When
            RDF data is shared with the public, as it is in Profiles Research Networking Software,
            it is called Linked Open Data (LOD).
        </p>
        <p>
            There are four types of application programming interfaces (APIs) in Profiles Research
            Networking Software.
        </p>
        <ul>
            <li>RDF crawl. Because Profiles Research Networking Software is a Semantic Web application,
                every profile has both an HTML page and a corresponding RDF document, which contains
                the data for that page in RDF/XML format. Web crawlers can follow the links embedded
                within the RDF/XML to access additional content.</li>
            <li>SPARQL endpoint. SPARQL is a programming language that enables arbitrary queries
                against RDF data. This provides the most flexibility in accessing data; however,
                the downsides are the complexity in coding SPARQL queries and performance. In general,
                the XML Search API (see below) is better to use than SPARQL.
                <li>XML Search API. This is a web service that provides support for the most common
                    types of queries. It is designed to be easier to use and to offer better performance
                    than SPARQL, but at the expense of fewer options. It enables full-text search across
                    all entity types, faceting, pagination, and sorting options. The request message
                    to the web service is in XML format, but the output is in RDF/XML format.
                    <li>
            Old XML based web services. This provides backwards compatibility for institutions
            that built applications using the older version of Profiles Research Networking
            Software. These web services do not take advantage of many of the new features of
            Profiles Research Networking Software. Users are encouraged to switch to one of
            the new APIs.
        </ul>
        <p>
            For more information about the APIs, please see the <a href="http://profiles.catalyst.harvard.edu/docs/ProfilesRNS_1.0.3_APIGuide.pdf">
                documentation</a> and <a href="http://profiles.catalyst.harvard.edu/docs/ProfilesRNS_1.0.3_API_Examples.zip">
                    example files</a>.
        </p>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlORCID" Visible="false">
        <h3>
            What is ORCID?</h3>
        <p>
            Researchers and scholars face the ongoing challenge of distinguishing scholarly
            activities from those of others with similar names. They need to be able to easily
            and uniquely attach their identity to scholarly work, such as articles, citations,
            grants, patents and datasets. As individuals collaborate across disciplines and
            institutions, they must interact with an increasing number and diversity of information
            systems. Entering data over and over again can be time-consuming, and often frustrating.
            ORCID is an open, non-profit, community-based effort to reduce that frustration.</p>
        <p>
            ORCID provides a registry of unique researcher identifiers and a transparent method
            of linking research activities and outputs to these identifiers. An ORCID iD is
            a persistent unique identifier that follows an individual throughout their career,
            and looks something like “0000-0003-0423-208X.”</p>
        <p>
            ORCID records hold non-sensitive information such as name, email, organization,
            and activities such as publication, grants, patents and other scholarly works. ORCID
            provides tools for individuals to manage data privacy.</p>
        <p>
            See <a target="_blank" href="http://orcid.org/about/what-is-orcid" title="About ORCID">
                What is ORCID</a> for additional information.</p>
        <h3>
            Why get an ORCID identifier?</h3>
        <p>
            Benefits of getting an ORCID iD include:</p>
        <ul>
            <li>Ensuring researchers get credit for their work</li>
            <li>Reducing time to identify scholarly output (see “Publisher integration,” below)</li>
            <li>Enabling scholars to keep track of and report on their work with funders, publishers
                and institutions</li>
            <li>Repurposing data for use in CV generation, citation repositories, Profiles, annual
                reports, faculty web-sites, and other systems (see “Grant submission integration,”
                below)</li>
            <li>Tying individuals to their scholarly work should make finding academic papers easier
                and more accurate</li>
        </ul>
        <p>
            Publisher integration: Elsevier, Thomson Reuters, Nature and other major publishers
            have begun integrating ORCID iDs into the manuscript submission process, and embedding
            ORCID identifiers across their scientific and scholarly research ecosystem. This
            will save authors time during submission, and enable automatic updating of author
            bibliographies when articles are published.</p>
        <p>
            Grant submission integration: NIH, NSF and other federal agencies are planning to
            integrate ORCID iDs into the ScienCV platform, for linking researchers, their grants,
            and their scientific output. The US federal government has been working to create
            a fed-wide profile system to streamline the grants and contract application process
            and reduce the data entry burden for investigators, and ORCID holds promise to be
            part of the solution.</p>
        <h3>
            What does the process entail?</h3>
        <p>
            There are benefits to having Profiles RNS initiate your ORCID record creation,
            or reporting an existing ORCID, as it paves the way for data exchange between Profiles RNS
            and ORCID on behalf of each scholar.</p>
        <p>
            When Profiles RNS initiates the process, we will upload your name and email address to
            create your ORCID record. Your email will be set as “public” within ORCID, unless
            you are hidden in your instituion directory, in which case you will be set to “limited” (for
            more on ORCID privacy settings, see the <a target="_blank" href="http://support.orcid.org/knowledgebase/articles/124518-orcid-privacy-settings"
                title="ORCID Privacy Settings">ORCID Privacy Settings</a>). You always have
            the ability to change these settings – the ORCID record is controlled by you, not
            your institution. Individuals who are in Profiles RNS will be asked if they want
            to push select information from Profiles RNS to ORCID at the time the ORCID record
            is created.</p>
        <p>
            ORCID will send you an email to claim your record. During the claim process they
            will suggest you set the default privacy setting for new works to be “public.” Data
            labeled as either “public” or “limited” will be accessible by your institution. You may be asked
            to allow your institution to be a Trusted Party (gain access to “limited” data), as a final step
            after claiming your ORCID record. If you do not claim your record within 10 days,
            it will become publicly visible. You can still claim the record at any time, and
            we encourage you to do so.</p>
        <p>
            For those not in Profiles RNS, or with no publication records showing in Profiles RNS,
            you can opt to add works using alternative means, such as the ORCID to Scopus integration.
            This option is available even if you have never used Scopus before. To use this,
            once logged into ORCID, choose &#8220;Update works,&#8221; then &#8220;Also see
            Import Research Activities,&#8221; to get the &#8220;Scopus to ORCID&#8221; option.
            Additional information on the Scopus integration with ORCID can be found <a target="_blank"
                href="http://www.info.sciverse.com/scopus/scopus-in-detail/orcid" title="Scopus ORCID integration">
                here</a>. You can use the same process but choose &#8220;CrossRef Metadata Search&#8221;
            to search CrossRef&#8217;s metadata on journal articles, conference proceedings
            and monographs, and add results to your ORCID profile. Additional information on
            the CrossRef Metadata search can be found <a href="http://labs.crossref.org/crossref-metadata-search/"
                title="CrossRef Metadata search" target="_blank">here</a>. Thomson Reuters will
            be adding integration to Web of Knowledge from within ORCID soon.</p>      
      
    </asp:Panel>
</div>
